using BygSpyWebAPI.Models;
using BygSpyWebAPI.Services.Interfaces;

namespace BygSpyWebAPI.Services
{
    public class SpyNotificationService : ISpyNotificationService
    {
        private readonly ISpyService _spyService;
        private readonly ISpyingObjectService _spyingObjectService;

        public SpyNotificationService(ISpyService spyService, ISpyingObjectService spyingObjectService)
        {
            _spyService = spyService;
            _spyingObjectService = spyingObjectService;
        }

        public async Task<List<Spy>> GetSpyNotification(List<Spy> spy)
        {
            var sortedSpyingObjects = new List<SpyingObject>();


            foreach (var obj in spy)
            {
                var tempList = await _spyingObjectService.GetAllSpyingObjectsBySpyId(obj.Id);
                sortedSpyingObjects.AddRange(tempList);


                foreach (var spyObj in sortedSpyingObjects)
                {
                    if (obj.Id == spyObj.SpyId) 
                    { 
                        var updatedStatus = await _spyingObjectService.GetGrundFromBfeAsync(spyObj.BFE);

                        if (spyObj.Status != updatedStatus)
                        {
                            obj.Notification = true;
                            await _spyService.UpdateSpyAsync(spyObj.SpyId, obj);
                            await _spyingObjectService.UpdateSpyingObjectAsync(spyObj.Id, spyObj);
                        }
                    }
                }
            }

            return spy;
        }

        public async Task<Spy> UpdateSpyNotification(Spy spy)
        {
            spy.Notification = false;

            var tempList = await _spyingObjectService.GetAllSpyingObjectsBySpyId(spy.Id);

            foreach (var obj in tempList)
            {
                obj.Status = await _spyingObjectService.GetGrundFromBfeAsync(obj.BFE);
                await _spyingObjectService.UpdateSpyingObjectAsync(obj.Id, obj);
            }

            await _spyService.UpdateSpyAsync(spy.Id, spy);
            return spy;
        }

        //public async Task<SpyingObject> UpdateSpyObjectStatus(SpyingObject spy)
        //{
        //    spy.Notification = false;
        //    await _spyService.UpdateSpyAsync(spy.Id, spy);
        //    return spy;
        //}
    }
}
