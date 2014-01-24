﻿using System;
using System.Globalization;

namespace FlatFiles
{
    /// <summary>
    /// Represents a column containing decimals.
    /// </summary>
    public class DecimalColumn : ColumnDefinition
    {
        /// <summary>
        /// Initializes a new instance of an DecimalColumn.
        /// </summary>
        /// <param name="columnName">The name of the column.</param>
        public DecimalColumn(string columnName)
            : base(columnName)
        {
            NumberStyles = NumberStyles.Number;
        }

        /// <summary>
        /// Gets the type of the values in the column.
        /// </summary>
        public override Type ColumnType
        {
            get { return typeof(Decimal); }
        }

        /// <summary>
        /// Gets or sets the format provider to use when parsing.
        /// </summary>
        public IFormatProvider FormatProvider { get; set; }

        /// <summary>
        /// Gets or sets the number styles to use when parsing.
        /// </summary>
        public NumberStyles NumberStyles { get; set; }

        /// <summary>
        /// Gets or sets the format string to use when converting the value to a string.
        /// </summary>
        public string OutputFormat { get; set; }

        /// <summary>
        /// Parses the given value, returning a Decimal.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>The parsed Decimal.</returns>
        public override object Parse(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            IFormatProvider provider = FormatProvider ?? CultureInfo.CurrentCulture;
            return Decimal.Parse(value.Trim(), NumberStyles, provider);
        }

        /// <summary>
        /// Formats the given object.
        /// </summary>
        /// <param name="value">The object to format.</param>
        /// <returns>The formatted value.</returns>
        public override string Format(object value)
        {
            decimal actual = (decimal)value;
            if (OutputFormat == null)
            {
                return actual.ToString(FormatProvider ?? CultureInfo.CurrentCulture);
            }
            else
            {
                return actual.ToString(OutputFormat, FormatProvider ?? CultureInfo.CurrentCulture);
            }
        }
    }
}