﻿using System;
using Logging;
using BookLogic;
using BookListService;
using BookStorageLogic;

namespace ConsoleBookTest
{
    class Program
    {
        private static readonly NLogger logger = new NLogger();
        static void Main(string[] args)
        {
            try
            {
                Book book1 = new Book("qqq", "www", "www", "www", 1995, 1000, 132);
                Book book2 = new Book("qq1q", "ww2w", "ww3w", "ww4w", 1995, 1200, 90);
                Book book3 = new Book("qqq", "www", "www", "www", 1995, 800, 175.0);
                Book book4 = new Book("qqq", "www", "www", "www", 1995, 800, 5);

                BookList bookList = new BookList(logger);
                Console.WriteLine("Adding books in BookList");
                bookList.AddBook(book1);
                bookList.AddBook(book2);
                bookList.AddBook(book3);
                Console.WriteLine("Added!");
                Console.WriteLine("removing books in BookList");
                bookList.RemoveBook(book3);
                Console.WriteLine("Removed!");

                Console.WriteLine("Save information about books in the binary file!");
                string path = @"D:\Epam\Epam.ASP.NET\NET.S.2018.Danilovich.10\BookStorageLogic\file.txt";
                IBookStorage bookStorage = new BinaryStorage(path);
                bookList.SaveBooksIntoStorage(bookStorage);
                Console.WriteLine("Saved!");
            }
            catch (FormatException error)
            {
                logger.WriteInfo("Format exseption");
                logger.WriteError(error.StackTrace);
            }
            catch (ArgumentNullException error)
            {
                logger.WriteInfo("Argument null exception");
                logger.WriteError(error.StackTrace);
            }
            catch (Exception error)
            {
                logger.WriteInfo("Unhandled exception:");
                logger.WriteError(error.StackTrace);
            }

        }
    }
}
