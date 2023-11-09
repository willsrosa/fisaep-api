using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisaep.Web.Models
{
    public class Content
    {
        public string identificador { get; set; }
        public string nome { get; set; }
        public string email_lead { get; set; }
        public string telefone { get; set; }
        public string empresa { get; set; }
        public string cargo { get; set; }
    }

    public class FirstConversion
    {
        public Content content { get; set; }
        public DateTime created_at { get; set; }
        public string cumulative_sum { get; set; }
        public string source { get; set; }
    }

    public class Content2
    {
        public string identificador { get; set; }
        public string email_lead { get; set; }
    }

    public class LastConversion
    {
        public Content2 content { get; set; }
        public DateTime created_at { get; set; }
        public string cumulative_sum { get; set; }
        public string source { get; set; }
    }

    public class Lead
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string job_title { get; set; }
        public string bio { get; set; }
        public DateTime created_at { get; set; }
        public string opportunity { get; set; }
        public string number_conversions { get; set; }
        public FirstConversion first_conversion { get; set; }
        public LastConversion last_conversion { get; set; }
    }

    public class RootObject
    {
        public List<Lead> leads { get; set; }
    }
}
