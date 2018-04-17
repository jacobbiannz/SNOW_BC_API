using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace snow_bc_api.src.model
{
    public class Image: Entity
    {
        public byte[] Data { get; set; }

        public string Path { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Type { get; set; }

       
        public bool IsMainImage { get; set; }
    }
}
