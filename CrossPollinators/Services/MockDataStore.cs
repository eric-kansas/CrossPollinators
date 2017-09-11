using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playground
{
    public class MockDataStore : IDataStore<ProjectModel>
    {
        bool isInitialized;
        List<ProjectModel> items;

        public MockDataStore()
        {
            items = new List<ProjectModel>();
            var _items = new List<ProjectModel>
            {
                new ProjectModel {
                    Id = Guid.NewGuid().ToString(),
                    HeaderImageURL = "First item",
                    HeaderText = "Header Text",
                    SubHeader = "This is a nice description",
                    Body = "Body text",
                    Author = new UserModel {
                        AvatarURL = "avatarurl",
                        Username = "kansas",
                        Organization = "org"
                    },
                    Tags = new ArrayList(new string[] {"css","gif","htm","html","txt","xml"})
                }
            };

            foreach (ProjectModel item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(ProjectModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ProjectModel item)
        {
            var _item = items.Where((ProjectModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((ProjectModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<ProjectModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ProjectModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
