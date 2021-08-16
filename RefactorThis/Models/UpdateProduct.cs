using System;
using System.Runtime.Serialization;

namespace refactor_this.Models
{
    [DataContract]
    public class UpdateProduct
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal Price { get; set; }

        [DataMember(Name = "deliveryPrice", EmitDefaultValue = false)]
        public decimal DeliveryPrice { get; set; }
    }
}