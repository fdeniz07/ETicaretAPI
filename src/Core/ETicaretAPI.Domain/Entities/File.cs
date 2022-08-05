using ETicaretAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretAPI.Domain.Entities
{
    public class File : BaseEntity
    {
        [NotMapped] // Ilgili base class daki propertynin migrate edilmemesini (base de virtual olarak isaretlenmeli) saglar
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }

        public string FileName { get; set; }

        public string Path { get; set; }

        //public decimal Size { get; set; }

    }
}
