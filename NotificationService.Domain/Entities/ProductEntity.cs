using System.Collections.Generic;

namespace NotificationService.Domain
{
    public class ProductEntity : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Cost { get; set; }
        public string Unit { get; set; }

        public ICollection<OrderEntity> Orders { get; private set; } = new List<OrderEntity>();
    }
}
