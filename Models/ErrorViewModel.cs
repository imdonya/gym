using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace gym.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
