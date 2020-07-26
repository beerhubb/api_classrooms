using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School_API.Models;

namespace School_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SchoolController : ControllerBase
    {
        public static readonly List<Studens> studens = new List<Studens> { };
        public static readonly List<Teacher> teachers = new List<Teacher> { };
        public static readonly List<Classroom> classrooms = new List<Classroom> { };

        [Route("GetStudenAll")]
        [HttpGet]
        public ActionResult<List<Studens>> GetStudenAll()
        {
            return studens;
        }

        [Route("GetStudenById/{StudenId}")]
        [HttpGet]
        public ActionResult<Studens> GetStudenById(string StudenId)
        {
            var item = studens.Where(it => it.StudentId == StudenId).FirstOrDefault();
            return Ok(item);
        }

        [Route("AddDataStuden")]
        [HttpPost]
        public Studens AddDataStuden([FromBody] Studens data)
        {
            data.StudentId = Guid.NewGuid().ToString();
            studens.Add(data);
            return data;
        }

        [Route("EditDataSutuden")]
        [HttpPut]
        public ActionResult EditDataStuden(Studens data)
        {
            var item = studens.Where(it => it.StudentId == data.StudentId).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            var Addstuden = new Studens
            {
                StudentId = item.StudentId,
                StudentName = data.StudentName,
                StudentAge = data.StudentAge,
                StudentTel = data.StudentTel
            };
            studens.Add(Addstuden);
            studens.Remove(item);
            return Ok(data);
        }

        [Route("DeleteStudenById/{StudenId}")]
        [HttpDelete]
        public ActionResult DeleteStudenById(string StudenId)
        {
            var item = studens.Where(it => it.StudentId == StudenId).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            studens.Remove(item);
            return Ok();
        }

        //Teacher

        [Route("GetStudenAll")]
        [HttpGet]
        public ActionResult<List<Teacher>> GetTeacherAll()
        {
            return teachers;
        }

        [Route("GetTeacherById/{TeacherId}")]
        [HttpGet]
        public ActionResult<Teacher> GetTeacherById(string StudenId)
        {
            var item = teachers.Where(it => it.TeacherId == StudenId).FirstOrDefault();
            return Ok(item);
        }

        [Route("AddDataTeacher")]
        [HttpPost]
        public Teacher AddDataTeacher([FromBody] Teacher data)
        {
            data.TeacherId = Guid.NewGuid().ToString();
            teachers.Add(data);
            return data;
        }

        [Route("EditTeacher")]
        [HttpPut]
        public ActionResult EditTeacher(Teacher data)
        {
            var item = teachers.Where(it => it.TeacherId == data.TeacherId).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            var Addstuden = new Teacher
            {
                TeacherId = data.TeacherId,
                TeacherName = data.TeacherName,
                TeacherTel = data.TeacherTel,
                SubjectTaught = data.SubjectTaught
            };
            teachers.Add(Addstuden);
            teachers.Remove(item);
            return Ok(data);
        }

        [Route("DeleteTeacherById/{TeacherId}")]
        [HttpDelete]
        public ActionResult DeleteTeacherById(string TeacherId)
        {
            var item = teachers.Where(it => it.TeacherId == TeacherId).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            teachers.Remove(item);
            return Ok();
        }

        //Classroom
        [Route("CreateClassroom")]
        [HttpPost]
        public Classroom CreateClassroom([FromBody] Classroom classroom)
        {
            classroom.ClassroomId = Guid.NewGuid().ToString();
            classrooms.Add(classroom);
            return classroom;
        }

        [Route("GetAllClassroom")]
        [HttpGet]
        public ActionResult<List<Classroom>> GetAllClassroom()
        {
            var result = classrooms.Where(it => true).ToList();
            return result;
        }

        [Route("GetClassroomById/{ClassroomId}")]
        [HttpGet]
        public ActionResult<Classroom> GetClassroomById(string ClassroomId)
        {
            var Getclass = classrooms.Where(it => it.ClassroomId == ClassroomId).FirstOrDefault();
            return Getclass;
        }

        [Route("AddTeacherInClassroom/{classroomid}/{teacherid}")]
        [HttpGet]
        public ActionResult<Classroom> AddTeacherInClassroom(string classroomid, string teacherid)
        {
            var room = classrooms.Where(it => it.ClassroomId == classroomid).FirstOrDefault();
            var teacher = teachers.Where(it => it.TeacherId == teacherid).FirstOrDefault();
            var newteacher = new Classroom
            {
                ClassroomId = room.ClassroomId,
                ClassroomName = room.ClassroomName,
                ClassTeacher = teacher,
                ClassStudent = room.ClassStudent
            };
            classrooms.Add(newteacher);
            classrooms.Remove(room);
            return newteacher;
        }

        [Route("AddTeacherInClassroom/{classroomid}/{studenId}")]
        [HttpGet]
        public ActionResult<Classroom> AddStudenInClassroom(string classroomid, string studenId)
        {
            var room = classrooms.Where(it => it.ClassroomId == classroomid).FirstOrDefault();
            var studen = studens.Where(it => it.StudentId == studenId).FirstOrDefault();
            var newteacher = new Classroom
            {
                ClassroomId = room.ClassroomId,
                ClassroomName = room.ClassroomName,
                ClassStudent = studen,
                ClassTeacher = room.ClassTeacher
            };
            classrooms.Add(newteacher);
            classrooms.Remove(room);
            return newteacher;
        }

        [Route("DeleteClassroomById/{ClassroomId}")]
        [HttpDelete]
        public ActionResult<Classroom> DeleteClassroomById(string ClassroomId)
        {
            var Delete_ById = classrooms.Where(it => it.ClassroomId == ClassroomId).FirstOrDefault();
            if (Delete_ById == null)
            {
                return NotFound();
            }
            classrooms.Remove(Delete_ById);
            return Ok();
        }
    }
}
