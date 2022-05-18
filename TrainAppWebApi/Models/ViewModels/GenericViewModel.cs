using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainAppWebApi.Models.ViewModels
{
    public class GenericViewModel<T>
    {
        public T Data { get; set; }
        public string[] Errors { get; set; }
    }
}
