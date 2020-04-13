using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDataBase.Validation
{
    public static class UserValidation
    {
        public static void RegistrationValidation(string firstName, string lastName, string thirdName, string passportSeria, string passportNumber, string issuedBy, string date5, string identNumber,
            int sex, string house, string housing, string flat, string zipCode, string phoneNumber, string email, string region, string district, int townType, string town,
            int streetType, string street, string login, string password)
        {
            if (firstName == null || firstName.Length == 0)
            {
                throw new ArgumentNullException("Имя не может быть пустым.");
            }
            else if (firstName.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Имя слишком длинное.");
            }

            if (lastName == null || lastName.Length == 0)
            {
                throw new ArgumentNullException("Фамилия не может быть пустой.");
            }
            else if (lastName.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Фамилия слишком длинная.");
            }

            if (thirdName == null || thirdName.Length == 0)
            {
                throw new ArgumentNullException("Отчество не может быть пустым.");
            }
            else if (thirdName.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Отчество слишком длинное.");
            }

            if (passportSeria == null || passportSeria.Length == 0)
            {
                throw new ArgumentNullException("Серия паспорта не можеи быть пустой.");
            }
            else if (passportSeria.Length > 2)
            {
                throw new ArgumentOutOfRangeException("Серия паспорта не может быть больше двух символов.");
            }

            if (!Int32.TryParse(passportNumber, out int result))
            {
                throw new ArgumentException("Неверный формат номера паспорт.");
            }
            else if (passportNumber.Length > 7)
            {
                throw new ArgumentOutOfRangeException("Номер паспорта не может быть больше семи цифр.");
            }

            if (issuedBy == null || issuedBy.Length == 0)
            {
                throw new ArgumentNullException("Орган выдачи паспорта не может быть пустым.");
            }
            else if (issuedBy.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Название органа выдачи паспорта слишком длинное.");
            }

            if (date5 == null || date5.Length == 0)
            {
                throw new ArgumentNullException("Дата выдачи паспорта не может быть пустой.");
            }
            else
            {
                if ((date5.Split(new string[] { "-" }, StringSplitOptions.None).Count() - 1) != 2)
                {
                    throw new ArgumentException("Неверный формат даты. Формат ввода ГГГГ-ММ-ДД");
                }

                string[] date5Array = date5.Split('-');

                if (!Int32.TryParse(date5Array[0], out result))
                {
                    throw new ArgumentException("Неверный год.");
                }
                else if (result > DateTime.Now.Year)
                {
                    throw new ArgumentException("Год не может быть больше текущего.");
                }

                if (!Int32.TryParse(date5Array[1], out result))
                {
                    throw new ArgumentException("Неверный месяц.");
                }

                if (!Int32.TryParse(date5Array[2], out result))
                {
                    throw new ArgumentException("Неверный день.");
                }

                if (!DateTime.TryParse(date5.Replace("-", "/"), out DateTime dateTime))
                {
                    throw new ArgumentException("Неверный ввод даты.");
                }
            }

            if (identNumber == null || identNumber.Length == 0)
            {
                throw new ArgumentNullException("Неверный ввод идентификационного номера.");
            }
            else if (identNumber.Length > 14)
            {
                throw new ArgumentOutOfRangeException("Идентификационный номер не может быть больше четырнадцати символов.");
            }

            if (sex > 2 || sex < 1)
            {
                throw new ArgumentException("Неверно выбран пол.");
            }

            if (house == null || house.Length == 0)
            {
                throw new ArgumentNullException("Номер дома не может быть пустым.");
            }
            else if (house.Length > 5)
            {
                throw new ArgumentOutOfRangeException("Номер дома не может быть больше пяти символов.");
            }

            if (flat.Length > 5)
            {
                throw new ArgumentOutOfRangeException("Номер квартиры не может быть больше пяти символов.");
            }

            if (!Int32.TryParse(zipCode, out result))
            {
                throw new ArgumentException("Неверный формат ввода почтового индекса");
            }
            else if (zipCode.Length > 7)
            {
                throw new ArgumentException("Почтовый индекс не может быть больше семи цифр.");
            }

            if (!Int64.TryParse(phoneNumber, out long resultLong))
            {
                throw new ArgumentException("Неверный формат ввода номера мобильного телефона. Вводите только цифры.");
            }

            if (email == null || email.Length == 0)
            {
                throw new ArgumentNullException("Адрес электронной почты не может быть пустым.");
            }
            else if (email.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Адрес электронной почты не может быть больше 50 символов.");
            }

            if (region == null || region.Length == 0)
            {
                throw new ArgumentNullException("Область не может быть пустой.");
            }
            else if (region.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Название области не может быть больше 40 символов.");
            }

            if (district == null || district.Length == 0)
            {
                throw new ArgumentNullException("Название района не может быть пустым.");
            }
            else if (district.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Название района не может быть больше 40 символов.");
            }

            if (townType < 1 || townType > 4)
            {
                throw new ArgumentOutOfRangeException("Неверно выбран тип города.");
            }

            if (town == null || town.Length == 0)
            {
                throw new ArgumentNullException("Название населенного пункта не может быть пустым.");
            }
            else if (town.Length > 15)
            {
                throw new ArgumentOutOfRangeException("Название населенного пункта не может быть больше 15 символов.");
            }

            if (streetType < 1 || streetType > 5)
            {
                throw new ArgumentOutOfRangeException("Неверно выбран тип улицы.");
            }

            if (street == null || street.Length == 0)
            {
                throw new ArgumentNullException("Название улицы не может быть пустым.");
            }
            else if (street.Length > 40)
            {
                throw new ArgumentOutOfRangeException("Название улицы не может быть больше 40 символов.");
            }

            if (login == null || login.Length == 0)
            {
                throw new ArgumentNullException("Логин не может быть пустым.");
            }
            else if (login.Length > 45)
            {
                throw new ArgumentOutOfRangeException("Логин не может быть больше 45 символов.");
            }

            if (password == null || password.Length == 0)
            {
                throw new ArgumentNullException("Пароль не может быть пустым.");
            }
            else if (password.Length > 45)
            {
                throw new ArgumentOutOfRangeException("Пароль не может быть больше 45 символво.");
            }
        }
    }
}
