using System.ComponentModel.DataAnnotations;
using Autocomplete.Demo.Data.DeviceUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Autocomplete.Demo.Service;

public class DeviceUserService(DeviceUserDbContext dbContext)
{
    [Authorize]
    public async Task<IEnumerable<DeviceUserModel>> GetDeviceUsersAsync()
    {
        return await dbContext.DeviceUsers.ToListAsync();
    }
    
    [Authorize]
    public async Task<DeviceUserModel?> GetDeviceUserAsync(int id)
    {
        return await dbContext.DeviceUsers.FindAsync(id);
    }
    
    [Authorize]
    public async Task AddDeviceUserAsync(DeviceUserModel deviceUserModel)
    {
        dbContext.DeviceUsers.Add(deviceUserModel);
        await dbContext.SaveChangesAsync();
    }
    
    [Authorize]
    public async Task UpdateDeviceUserAsync(DeviceUserModel deviceUserModel)
    {
        dbContext.DeviceUsers.Update(deviceUserModel);
        await dbContext.SaveChangesAsync();
    }
    
    [Authorize]
    public async Task DeleteDeviceUserAsync(int id)
    {
        var deviceUser = await dbContext.DeviceUsers.FindAsync(id);
        if (deviceUser == null)
        {
            return;
        }
        dbContext.DeviceUsers.Remove(deviceUser);
        await dbContext.SaveChangesAsync();
    }
    
    [Authorize]
    public async Task<bool> DeviceUserExistsWithCardIdAsync(string cardId)
    {
        return await dbContext.DeviceUsers.AnyAsync(e => e.CardId == cardId);
    }
    
    [Authorize]
    public async Task<bool> DeviceUserExistsWithKeypadIdAsync(string keypadId)
    {
        return await dbContext.DeviceUsers.AnyAsync(e => e.KeypadId == keypadId);
    }
    
    [Authorize]
    public async Task<bool> DeviceUserExistsWithEnrolmentIdAsync(string enrolmentId)
    {
        return await dbContext.DeviceUsers.AnyAsync(e => e.EnrolmentId == enrolmentId);
    }
    
    [Authorize]
    public async Task<bool> DeviceUserExistsWithPinAsync(string pin)
    {
        return await dbContext.DeviceUsers.AnyAsync(e => e.Pin == pin);
    }
    
    [Authorize]
    public async Task<ValidationResult?> ValidateDeviceUserAsync(DeviceUserModel deviceUserModel)
    {
        var memberNames = new List<string>();
        if (await DeviceUserExistsWithCardIdAsync(deviceUserModel.CardId))
        {
            memberNames.Add(nameof(DeviceUserModel.CardId));
        }
        
        if (await DeviceUserExistsWithKeypadIdAsync(deviceUserModel.KeypadId))
        {
            memberNames.Add(nameof(DeviceUserModel.KeypadId));
        }
        
        if (await DeviceUserExistsWithEnrolmentIdAsync(deviceUserModel.EnrolmentId))
        {
            memberNames.Add(nameof(DeviceUserModel.EnrolmentId));
        }
        
        if (await DeviceUserExistsWithPinAsync(deviceUserModel.Pin))
        {
            memberNames.Add(nameof(DeviceUserModel.Pin));
        }

        return memberNames.Count != 0 ? new ValidationResult("Device user already exists with the same card ID, keypad ID, enrolment ID or PIN.", memberNames) : null;
    } 
}