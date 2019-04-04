using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities
{
    public class Survey : IEntity
    {
        public int ID { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public int Code { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}")]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public int OrganisationID { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
}
