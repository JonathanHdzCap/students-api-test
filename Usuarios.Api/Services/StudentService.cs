using Usuarios.Api.Models;
using Usuarios.Api.Repository.Interfaces;

namespace Usuarios.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly IEmailRepository _emailRepository;

        public StudentService(IStudentRepository studentRepository, IAddressRepository addressRepository,
            IPhoneRepository phoneRepository, IEmailRepository emailRepository)
        {
            _studentRepository = studentRepository;
            _addressRepository = addressRepository;
            _phoneRepository = phoneRepository;
            _emailRepository = emailRepository;
        }

        #region Student
        /// <summary>
        /// Agregar nuevo estudiante con un Email, Direccion y Telefono
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<int> AddNewStudentAsync(Student student)
        {
            try
            {
                if (student.Emails is null || student.Phones is null || student.Addresses is null ||
                        student.Emails.Count <= 0  || student.Phones.Count <= 0 || student.Addresses.Count <= 0)
                {
                    return 0;
                }

                var dateNow = DateTime.Now;
                foreach (var itemPhone in student.Phones)
                {
                    itemPhone.CreatedOn = dateNow;
                    itemPhone.IsActive = true;
                }
                foreach (var itemAddress in student.Addresses)
                {
                    itemAddress.IsActive = true;
                }
                foreach (var itemEmail in student.Emails)
                {
                    itemEmail.CreatedOn = dateNow;
                    itemEmail.IsActive = true;
                }

                var resultStudentId = await _studentRepository.CreateStudentComplete(student);
                return resultStudentId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        public async Task<int> DeleteStudentAsync(int studentId)
        {
            try
            {
                if (studentId <= 0) return 0;
                var result = await _studentRepository.DeleteStudentComplete(studentId);
                return result > 0 ? studentId : 0;

            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            try
            {
                return await _studentRepository.GetAll();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<Student> GetStudentAsync(int idStudent)
        {
            try
            {
                return await _studentRepository.GetById(idStudent) ?? new Student();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<int> UpdateStudentAsync(int studentId, Student student)
        {
            try
            {
                var result = await _studentRepository.Update(studentId, student);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
        #endregion Student
      
        #region Email
        public async Task<List<Email>> GetAllEmailsAsync(int studentId)
        {
            try
            {
                return await _emailRepository.GetAll(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<string?> AddEmailAsync(Email emailData)
        {
            try
            {
                return await _emailRepository.Create(emailData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<int> UpdateEmailAsync(string email, Email emailData)
        {
            try
            {
                return await _emailRepository.Update(email,emailData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
        public async Task<int> DeleteEmailAsync(string email)
        {
            try
            {
                return await _emailRepository.Delete(email);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
        #endregion Email


        #region Phones
        public async Task<List<Phone>> GetAllPhonesAsync(int studentId)
        {
            try
            {
                return await _phoneRepository.GetAll(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public async Task<int?> AddPhoneAsync(Phone phone)
        {
            try
            {
                return await _phoneRepository.Create(phone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<int> UpdatePhoneAsync(int phoneId, Phone phone)
        {
            try
            {
                return await _phoneRepository.Update(phoneId, phone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        public async Task<int> DeletePhoneAsync(int phoneId)
        {
            try
            {
                return await _phoneRepository.Delete(phoneId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
        #endregion Phones


        #region Addresses
        public async Task<List<Address>> GetAllAddressesAsync(int studentId)
        {
            try
            {
                return await _addressRepository.GetAll(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public async Task<int?> AddAddressAsync(Address address)
        {
            try
            {
                return await _addressRepository.Create(address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<int> UpdateAddressAsync(int addressId, Address address)
        {
            try
            {
                return await _addressRepository.Update(addressId, address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        public async Task<int> DeleteAddressAsync(int addressId)
        {
            try
            {
                return await _addressRepository.Delete(addressId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
        #endregion Addresses

    }
}
