namespace Carpool.DAL.Infrastructure.Services.Student
{
    public interface IStudentService
    {
        Task<Model.Student> GetStudentBasicInfos(int studentId);
    }
}
