using System.ComponentModel;

namespace AycemOtomasyon.DTO.Enum
{
    public enum OrderItemStatus
    {
        [Description("Oluşturuldu")]
        Created = 0,
        [Description("İptal Edildi")]
        Canceled = 1,
        [Description("Tamamlandı")]
        Completed = 2
    }
}
