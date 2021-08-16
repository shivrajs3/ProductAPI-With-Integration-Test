using System;
using System.Runtime.Serialization;

namespace refactor_this.Models
{
    [DataContract]
    public class ProductOptions
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }
    }
}