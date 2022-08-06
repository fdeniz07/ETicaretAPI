using ETicaretAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretAPI.Domain.Entities
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }

        public string Path { get; set; }

        public long Size { get; set; }

        public string Storage { get; set; }

        [NotMapped] // Ilgili base class daki propertynin migrate edilmemesini (base de virtual olarak isaretlenmeli) saglar
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
