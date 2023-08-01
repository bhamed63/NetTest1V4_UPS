using NetTest1V4_UPS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetTest1V4_UPS.DataServices.Base
{
    public class GetDataListResult<T>
    {
        public int Code { get; set; }
        public Meta Meta { get; set; }
        public List<T> Data { get; set; }
    }

    public class GetDataResult
    {
        public int Code { get; set; }
        public Meta Meta { get; set; }
        public Object Data { get; set; }
    }

    public class Meta
    {
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Total { get; set; }
        public int Pages { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }

    public class CommandResult
    {
        protected static int _successCode = 0;

        public int Code { get; set; }
        public Object Data { get; set; }
        public bool IsSuccessful { get { return Code == _successCode; } }

        public string GetMessages()
        {
            var errors = JsonConvert.DeserializeObject<List<FieldError>>(Data.ToString());
            return String.Join(System.Environment.NewLine, errors.Select(c => String.Format("{0}: {1}", c.Field, c.Message)));
        }

    }

    public class CreateResult : CommandResult
    {
        public CreateResult()
        {
            _successCode = 201;
        }

        public int GetEmployeeId()
        {
            return JsonConvert.DeserializeObject<Employee>(Data.ToString()).Id;
        }
    }

    public class RemoveResult : CommandResult
    {
        public RemoveResult()
        {
            _successCode = 204;
        }
    }

    public class FieldError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}