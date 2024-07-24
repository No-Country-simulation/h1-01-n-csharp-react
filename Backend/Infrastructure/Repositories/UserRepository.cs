using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Users;
using DTOs.User;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMedicRepository _medicRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(ApplicationDbContext context,
            IMedicRepository medicRepository,
            IPatientRepository patientRepository,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _medicRepository = medicRepository;
            _patientRepository = patientRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<DeletedUserGetDto>> GetDeletedUsers()
        {
            var users = await _context.Users
                .Where(u => u.IsDeleted)
                .ToListAsync();

            var deletedUsersDto = new List<DeletedUserGetDto>();

            foreach (var user in users)
            {
                // Get user role
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                //Map and add the role to the dto
                var userDto = _mapper.Map<DeletedUserGetDto>(user);
                userDto.Role = role;

                deletedUsersDto.Add(userDto);
            }

            return deletedUsersDto;
        }

        public async Task<bool> IsDNIInUse(string DNI)
        {
            bool isMedic = await _medicRepository.FindDNIInMedics(DNI);
            bool isPatient = await _patientRepository.FindDNIInPatients(DNI);

            return isMedic || isPatient;
        }

        public bool Delete(ApplicationUser user)
        {
            if (user == null)
                return false;

            _context.Users.Remove(user);

            return true;
        }

        public void Update(ApplicationUser user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
