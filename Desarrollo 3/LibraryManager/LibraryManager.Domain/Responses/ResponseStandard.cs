using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Domain.Abstractions;

namespace LibraryManager.Domain.Responses
{
    public class ResponseStandard<T>
    {
        public bool success { get; set; }
        public string message { get; set; } = null!;
        public T? data { get; set; }
    }

    public class ResponseStandardPagination<T>
    {
        public bool success { get; set; }
        public string message { get; set; } = null!;

        public T? data { get; set; }
        public long totalCount { get; set; }
        public dynamic? ExtraValues { get; set; } = null;
    }

    public class ResponseStandardFactory
    {
        /// <summary>
        ///     Builds a successfull or failed ResponseStandard object depending the state of the result
        /// </summary>
        public static ResponseStandard<string?> HandleResultValue(Result result) =>
            result.IsSuccess ? EmptySuccess : WithError(result.Error);

        /// <summary>
        ///     Builds a ResponseStandard object with empty data
        /// </summary>
        /// <param name="success">True if it is a success result, false otherwise</param>
        public static ResponseStandard<string?> Empty(bool success) =>
            success ? EmptySuccess : EmptyFailed;

        /// <summary>
        ///     Builds a failure ResponseStandard object with the specified error
        /// </summary>
        public static ResponseStandard<string?> WithError(string error) => new ResponseStandard<string?>
        {
            success = false,
            message = "failed",
            data = error
        };

        /// <summary>
        ///     Builds a failure ResponseStandard object with the specified error
        /// </summary>
        public static ResponseStandard<string?> WithError(Error error) => new ResponseStandard<string?>
        {
            success = false,
            message = error.Code,
            data = error.Name
        };

        /// <summary>
        ///     Builds a successfull or failed ResponseStandard object depending the state of the result
        /// </summary>
        public static ResponseStandard<T?> HandleResultValue<T>(Result<T> result) =>
            result.IsSuccess
                ? WithData(result.Value)
                : new ResponseStandard<T?>
                {
                    success = false,
                    message = result.Error.Name,
                    data = default
                };

        /// <summary>
        ///     Builds a success ResponseStandard object with the specified data
        /// </summary>
        public static ResponseStandard<T?> WithData<T>(T data) => new ResponseStandard<T?>
        {
            success = true,
            message = "success",
            data = data
        };

        /// <summary>
        ///     Builds a success ResponseStandardPagination object with the specified data
        /// </summary>
        public static ResponseStandardPagination<T?> WithPagination<T>(
            T data,
            long total,
            dynamic? extraValues = null
        ) => new ResponseStandardPagination<T?>
        {
            success = true,
            message = "success",
            data = data,
            totalCount = total,
            ExtraValues = extraValues
        };

        private static ResponseStandard<string?> EmptySuccess => new ResponseStandard<string?>
        {
            success = true,
            message = "success",
            data = null
        };

        private static ResponseStandard<string?> EmptyFailed => new ResponseStandard<string?>
        {
            success = false,
            message = "failed",
            data = null
        };
    }
}
