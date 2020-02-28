﻿using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace SharpenUp.Models
{
    public class Monitor
    {
        /// <summary>
        /// The ID of the monitor (can be used for monitor-specific requests).
        /// </summary>
        [JsonProperty( PropertyName = "id" )]
        public int Id { get; set; }

        /// <summary>
        /// The friendly name of the monitor.
        /// </summary>
        [JsonProperty( PropertyName = "friendly_name" )]
        public string FriendlyName { get; set; }

        /// <summary>
        /// The URL/IP of the monitor.
        /// </summary>
        [JsonProperty( PropertyName = "url" )]
        public string URL { get; set; }

        /// <summary>
        /// The type of the monitor.
        /// </summary>
        [JsonProperty( PropertyName = "type" )]
        public MonitorType MonitorType { get; set; }

        // TODO: Come back and figure out how to parse this.
        /// <summary>
        /// Used only for "Port monitoring (monitor>type = 4)" and shows which pre-defined port/service is monitored or if a custom port is monitored.
        /// </summary>
        //[JsonProperty( PropertyName = "sub_type" )]
        //public MonitorSubType MonitorSubType { get; set; }

        // TODO: Come back and figure out how to parse this.
        /// <summary>
        /// Used only for "Keyword monitoring (monitor>type = 2)" and shows "if the monitor will be flagged as down when the keyword exists or not exists".
        /// </summary>
        //[JsonProperty( PropertyName = "keyword_type" )]
        //public KeywordType KeywordType { get; set; }

        /// <summary>
        /// The value of the keyword.
        /// </summary>
        [JsonProperty( PropertyName = "keyword_value" )]
        public string KeywordValue { get; set; }

        /// <summary>
        /// Used for password-protected web pages (HTTP Basic Auth). Available for HTTP and keyword monitoring.
        /// </summary>
        [JsonProperty( PropertyName = "http_username" )]
        public string HttpUsername { get; set; }

        /// <summary>
        /// Used for password-protected web pages (HTTP Basic Auth). Available for HTTP and keyword monitoring.
        /// </summary>
        [JsonProperty( PropertyName = "http_password" )]
        public string HttpPassword { get; set; }

        // TODO: Come back and figure out how to parse this.
        /// <summary>
        /// Used only for "Port monitoring (monitor>type = 4)" and shows the port monitored.
        /// </summary>
        //[JsonProperty( PropertyName = "port" )]
        //public int Port { get; set; }

        /// <summary>
        /// The interval for the monitoring check (300 seconds by default).
        /// </summary>
        [JsonProperty( PropertyName = "interval" )]
        public int Interval { get; set; }

        /// <summary>
        /// The status of the monitor. When used with the editMonitor method 0 (to pause) or 1 (to start) can be sent.
        /// </summary>
        [ExcludeFromCodeCoverage]
        [JsonProperty( PropertyName = "status" )]
        public MonitorStatus Status { get; set; }

        /// <summary>
        /// The uptime ratio of the monitor calculated since the monitor is created.
        /// </summary>
        [ExcludeFromCodeCoverage]
        [JsonProperty( PropertyName = "all_time_uptime_ratio" )]
        public double AllTimeUptimeRatio { get; set; }

        /// <summary>
        /// The durations of all time up-down-paused events in seconds.
        /// </summary>
        [ExcludeFromCodeCoverage]
        [JsonProperty( PropertyName = "all_time_uptime_durations" )]
        public UptimeDurations AllTimeUptimeDurations { get; set; }

        /// <summary>
        /// The uptime ratio of the monitor for the given periods (if there is more than 1 period, then the values are seperated with "-").
        /// </summary>
        [ExcludeFromCodeCoverage]
        [JsonProperty( PropertyName = "custom_uptime_ratios" )]
        public List<double> CustomUptimeRatios { get; set; }

        /// <summary>
        /// The uptime ratio of the monitor for the given ranges (if there is more than 1 range, then the values are seperated with "-").
        /// </summary>
        [ExcludeFromCodeCoverage]
        [JsonProperty( PropertyName = "custom_uptime_ranges" )]
        public List<double> CustomUptimeRanges { get; set; }

        /// <summary>
        /// The average value of the response times (requires response_times=1).
        /// </summary>
        [ExcludeFromCodeCoverage]
        [JsonProperty( PropertyName = "average_response_time" )]
        public double AverageResponseTime { get; set; }

        /// <summary>
        /// Used for setting custom HTTP headers for the monitor.
        /// </summary>
        [JsonProperty( PropertyName = "custom_http_headers" )]
        public string CustomHttpHeaders { get; set; }

        /// <summary>
        /// For ex: 404:0_200:1 (to accept 404 as down and 200 as up).
        /// </summary>
        [JsonProperty( PropertyName = "custom_http_statuses" )]
        public string CustomHttpStatuses { get; set; }

        /// <summary>
        /// The HTTP method to be used.
        /// </summary>
        [JsonProperty( PropertyName = "http_method" )]
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// The format of data to be sent with POST, PUT, PATCH, DELETE, OPTIONS HTTP methods.
        /// </summary>
        [JsonProperty( PropertyName = "post_type" )]
        public PostType PostType { get; set; }

        /// <summary>
        /// The data to be sent with POST, PUT, PATCH, DELETE, OPTIONS HTTP methods.
        /// </summary>
        [JsonProperty( PropertyName = "post_value" )]
        public string PostValue { get; set; }

        /// <summary>
        /// Sets the Content-Type for POST, PUT, PATCH, DELETE, OPTIONS HTTP methods.
        /// </summary>
        [JsonProperty( PropertyName = "post_content_type" )]
        public PostContentType PostContentType { get; set; }
    }

    public enum MonitorType
    {
        HTTP = 1,
        Keyword = 2,
        Ping = 3,
        Port = 4
    }

    public enum MonitorSubType
    {
        None = 0,
        HTTP = 1,
        HTTPS = 2,
        FTP = 3,
        SMTP = 4,
        POP3 = 5,
        IMAP = 6,
        Custom = 99
    }

    public enum KeywordType
    {
        Exists = 1,
        NotExists = 2
    }

    public enum MonitorStatus
    {
        Paused = 0,
        NotChecked = 1,
        Up = 2,
        SeemsDown = 8,
        Down = 9
    }

    public class UptimeDurations
    {
        public int Up { get; set; }
        public int Down { get; set; }
        public int Paused { get; set; }
    }

    public enum HttpMethod
    {
        HEAD = 1,
        GET = 2,
        POST = 3,
        PUT = 4,
        PATCH = 5,
        DELETE = 6,
        OPTIONS = 7
    }

    public enum PostType
    {
        KeyValue = 1,
        RawData = 2
    }

    public enum PostContentType
    {
        HTML = 0,
        JSON = 1
    }
}
