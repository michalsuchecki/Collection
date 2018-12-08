using System.Collections.Generic;
using Collection.Entity.Item;

namespace Collection.Core.Repositories
{
    public interface IImageRepository : IRepository<ItemImage>
    {
        IEnumerable<ItemImage> GetItemImages(int itemId);
        ItemImage GetItemPreviewImage(int itemId);
        IEnumerable<ItemImage> GetItemsImages(int[] itemIds);
        IEnumerable<ItemImage> GetItemsPreviewImages(int[] itemsIds);
    }
}
