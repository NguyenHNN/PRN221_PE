using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Entities;

public partial class OilPaintingArt
{
    public int OilPaintingArtId { get; set; }

    [Required(ErrorMessage = "ArtTitle is required")]
    [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "ArtTitle must greater than 4 characters")]
    [RegularExpression(@"^(?:[A-Z][a-zA-Z@$&()]*\s?)+$", ErrorMessage = "Each word of the ArtTitle must begin with a capital letter, and the title can include only the special characters @, $, &, (, ).")]
    public string ArtTitle { get; set; } = null!;

    [Required(ErrorMessage = "OilPaintingArtLocation is required")]
    public string OilPaintingArtLocation { get; set; } = string.Empty;

    [Required(ErrorMessage = "OilPaintingArtStyle is required")]
    public string OilPaintingArtStyle { get; set; } = string.Empty;

    [Required(ErrorMessage = "Artist is required")]
    public string Artist { get; set; } = string.Empty;

    [Required(ErrorMessage = "NotablFeatures is required")]
    public string NotablFeatures { get; set; } = string.Empty;

    [Required(ErrorMessage = "PriceOfOilPaintingArt is required")]
    public decimal PriceOfOilPaintingArt { get; set; }

    [Required(ErrorMessage = "StoreQuantity is required")]
    [Range(0, 50, ErrorMessage = "StoreQuantity must in range 0 to 50")]
    public int StoreQuantity { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public string? SupplierId { get; set; }

    public virtual SupplierCompany? Supplier { get; set; }
}
