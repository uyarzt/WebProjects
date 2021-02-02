using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppForTesting.Models.TestingModels
{
    public class TestType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestType()
        {
            this.Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
    }
}