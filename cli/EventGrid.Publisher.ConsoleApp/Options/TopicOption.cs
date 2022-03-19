using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGrid.Publisher.ConsoleApp.Options
{
    internal class TopicOption : Option
    {
        public TopicOption(Type? argumentType = null, Func<object?>? getDefaultValue = null, ArgumentArity arity = default) : 
            base("--topic", "The name of the topic where the event should be sennd to.", argumentType, getDefaultValue, arity)
        {
            var topicName = new Option<string>("--topic", "The name of the topic where the event should be sennd to.");
            AddAlias("-t");
            IsRequired = true;
        }
    }
}
