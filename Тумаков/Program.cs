using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тумаков
{
    internal class Program
    {
        public enum AccountType
        {
            Текущий_счет,
            Сберегательный_счет
        }
        class BankAccount
        {
            private static int numberOfBankAccounts;
            private int accountNumber;
            private decimal accountBalance;
            private AccountType bankAccountType;
            public int AccountNumber
            {
                get
                {
                    return accountNumber;
                }
            }
            public decimal AccountBalance
            {
                get
                {
                    return accountBalance;
                }
            }
            public AccountType BankAccountType
            {
                get
                {
                    return bankAccountType;
                }
            }

            public static int NumberOfBankAccounts { get => numberOfBankAccounts; set => numberOfBankAccounts = value; }
            private void ChangeNumberOfBankAccounts()
            {
                NumberOfBankAccounts++;
            }
            public bool WithdrawMoneyFromAccount(decimal withdrawalAmount)
            {
                if ((accountBalance - withdrawalAmount > 0) && (withdrawalAmount > 0))
                {
                    accountBalance -= withdrawalAmount;
                    return true;
                }

                return false;
            }
            public bool PutMoneyIntoAccount(decimal depositedAmoun)
            {
                if (depositedAmoun > 0)
                {
                    accountBalance += depositedAmoun;
                    return true;
                }

                return false;
            }
            public bool TransferringMoney(BankAccount withdrawalAccount, decimal withdrawalAmount)
            {
                if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
                {
                    accountBalance += withdrawalAmount;
                    withdrawalAccount.accountBalance -= withdrawalAmount;
                    return true;
                }

                return false;
            }
            public BankAccount(AccountType bankAccountType)
            {
                accountNumber = NumberOfBankAccounts;
                accountBalance = 0;
                this.bankAccountType = bankAccountType;
                ChangeNumberOfBankAccounts();
            }
        }
        class Song
        {
            private string songName;
            private string songAuthor;
            private Song previousSong;
            public string SongName
            {
                get
                {
                    return songName;
                }
            }
            public string SongAuthor
            {
                get
                {
                    return songAuthor;
                }
            }
            public Song PreviousSong
            {
                get
                {
                    return previousSong;
                }
            }
            public string Title
            {
                get
                {
                    return songName + " " + songAuthor;
                }
            }
            public override bool Equals(object transmittedSong)
            {
                Song song = transmittedSong as Song;

                if ((song != null) && (song.SongName == songName) && (song.SongAuthor == songAuthor))
                {
                    return true;
                }

                return false;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public Song(string songName, string songAuthor, Song previousSong)
            {
                this.songName = songName;
                this.songAuthor = songAuthor;
                this.previousSong = previousSong;
            }
            public Song(string songName, string songAuthor)
            {
                this.songName = songName;
                this.songAuthor = songAuthor;
                previousSong = null;
            }
        }
        static string ReversesTheOrderOfCharactersInString(string sourceString)
        {
            char[] stringCharacterArray = sourceString.ToCharArray();

            Array.Reverse(stringCharacterArray);

            return String.Concat(stringCharacterArray);
        }
        static bool ChecksObjectImplementsIFormattableUsingIs(object checkedObject)
        {
            if (checkedObject is IFormattable)
            {
                return true;
            }

            return false;
        }
        static bool ChecksObjectImplementsIFormattableUsingAs(object checkedObject)
        {
            if (checkedObject as IFormattable == null)
            {
                return false;
            }

            return true;
        }
        static bool ExtractingEmailFromDataString(ref string dataString)
        {
            string[] data = dataString.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length == 2)
            {
                dataString = data[1];
                return true;
            }
            else
            {
                return false;
            }
        }
        class ClassImplementingIFormattables : IFormattable
        {
            private int firstValue = 10;

            public override string ToString()
            {
                return ToString("G", NumberFormatInfo.CurrentInfo);
            }

            public string ToString(string format)
            {
                return ToString(format, NumberFormatInfo.CurrentInfo);
            }

            public string ToString(string format, IFormatProvider provider)
            {
                return firstValue.ToString("G", provider);
            }
        }

        static void Main()
        {
            bool tasksEnd = false;
            string taskNumber;
            Console.Clear();
            Console.WriteLine("{0, 112}", "УПРАЖНЕНИЕ 8.1. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 7.3, НО ДОБАВЛЕН МЕТОД ПЕРЕВОДА ДЕНЕГ С ОДНОГО СЧЕТА НА ДРУГОЙ\n");

            BankAccount firstBankAccount = new BankAccount(AccountType.Текущий_счет);
            BankAccount secondBankAccount = new BankAccount(AccountType.Текущий_счет);
            bool putMoneyResult, transferringMoneyResult;

            putMoneyResult = firstBankAccount.PutMoneyIntoAccount(500000.55M);
            putMoneyResult &= secondBankAccount.PutMoneyIntoAccount(100000.87M);

            if (putMoneyResult)
            {
                Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                  $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");

                transferringMoneyResult = firstBankAccount.TransferringMoney(secondBankAccount, 50000.87M);

                if (transferringMoneyResult)
                {
                    Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                      $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");
                }
                else
                {
                    Console.WriteLine("На банковском счету недостаточно средств или вы неверно ввели сумму!");
                }

                transferringMoneyResult = secondBankAccount.TransferringMoney(firstBankAccount, 500000);

                if (transferringMoneyResult)
                {
                    Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\t" +
                                      $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей");
                }
                else
                {
                    Console.WriteLine("На банковском счету недостаточно средств или вы неверно ввели сумму!");
                }
            }
            else
            {
                Console.WriteLine("Вы неверно ввели сумму!");
            }



            Console.WriteLine("{0, 111}", "УПРАЖНЕНИЕ 8.2. ПРОГРАММА ПОЛУЧАЕТ СТРОКУ И ВОЗВРАЩАЕТ НОВУЮ, СИМВОЛЫ В КОТОРОЙ ИДУТ В ОБРАТНОМ ПОРЯДКЕ\n");

            string userString, newString;

            Console.Write("Введите строку: ");
            userString = Console.ReadLine();

            newString = ReversesTheOrderOfCharactersInString(userString);
            Console.Write($"Из строки {userString} получилась строка: {newString}");


            Console.WriteLine("{0, 111}", "УПРАЖНЕНИЕ 8.4. ПРОГРАММА ПРОВЕРЯЕТ РЕАЛИЗУЕТ ЛИ ПЕРЕДАВАЕМЫЙ ОБЪЕКТ ИНТРЕФЕЙС System.IFormattable\n");

            ClassImplementingIFormattables firstObject = new ClassImplementingIFormattables();
            BankAccount secondObject = new BankAccount(AccountType.Текущий_счет);

            if (ChecksObjectImplementsIFormattableUsingIs(firstObject))
            {
                Console.WriteLine("Объект реализует интерфейс System.IFormattable");
            }
            else
            {
                Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
            }

            if (ChecksObjectImplementsIFormattableUsingIs(secondObject))
            {
                Console.WriteLine("Объект реализует интерфейс System.IFormattable");
            }
            else
            {
                Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
            }

            if (ChecksObjectImplementsIFormattableUsingAs(firstObject))
            {
                Console.WriteLine("Объект реализует интерфейс System.IFormattable");
            }
            else
            {
                Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
            }

            if (ChecksObjectImplementsIFormattableUsingAs(secondObject))
            {
                Console.WriteLine("Объект реализует интерфейс System.IFormattable");
            }
            else
            {
                Console.WriteLine("Объект не реализует интерфейс System.IFormattable");
            }



            Console.WriteLine("{0, 113}", "ДОМАШНЕЕ ЗАДАНИЕ 8.1. ПРОГРАММА ВЫДЕЛЯЕТ ИЗ ВХОДНОГО ФАЙЛА С ДАННЫМИ E-MAIL И ЗАПИСЫВАЕТ ЕГО В НОВОМ ФАЙЛЕ\n");

            bool extractingResult;
            string[] dataFile = File.ReadAllLines("ProgramFiles/DataFile.txt");

            for (int i = 0; i < dataFile.Length; i++)
            {
                string dataString = dataFile[i];
                extractingResult = ExtractingEmailFromDataString(ref dataString);
                if (extractingResult)
                {
                    File.AppendAllText("ProgramFiles/EmailFile.txt", dataString + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("Входные данные заполнены с ошибкой. Проверьте входной файл!");
                    break;
                }
            }
            Console.WriteLine("{0, 110}", "ДОМАШНЕЕ ЗАДАНИЕ 8.2. ПРОГРАММА СОЗДАЕТ СПИСОК ПЕСЕН, ВЫВОДИТ ИХ НА ЭКРАН И СРАВНИВАЕТ ДВЕ ИЗ НИХ\n");

            Song firstSong = new Song("Я Русский", "Shaman");
            Song secondSong = new Song("Моя Россия", "Shaman", firstSong);
            Song thirdSong = new Song("Вороны мои", "Shaman", secondSong);
            Song fourthSong = new Song("Гимн России", "Shaman", thirdSong);

            List<Song> songList = new List<Song> { firstSong, secondSong, thirdSong, fourthSong };

            foreach (Song song in songList)
            {
                Console.WriteLine(song.Title);
            }

            if (firstSong.Equals(secondSong))
            {
                Console.WriteLine("\nПесни равны!");
            }
            else
            {
                Console.WriteLine("\nПесни неравны!");
            }

        }
           
    }
}
