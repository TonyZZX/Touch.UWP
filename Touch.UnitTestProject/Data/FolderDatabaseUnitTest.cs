﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Touch.Data;

namespace Touch.UnitTestProject.Data
{
    [TestClass]
    public class FolderDatabaseUnitTest
    {
        /// <summary>
        ///     重复初始化两次数据库
        /// </summary>
        [TestMethod]
        public void DuplicateCreateTest()
        {
            FolderDatabase.Init();
            FolderDatabase.Init();
        }

        /// <summary>
        ///     插入并读出数据
        /// </summary>
        [TestMethod]
        public void InsertAndGetFoldersTest()
        {
            FolderDatabase.Drop();
            FolderDatabase.Create();
            FolderDatabase.Insert("test_data_1", "");
            FolderDatabase.Insert("test_data_2", "");
            FolderDatabase.Insert("test_data_3", "");
            var folders = FolderDatabase.GetFolders();
            var count = 1;
            foreach (var folder in folders)
                Assert.AreEqual("test_data_" + count++, folder.FolderPath);
        }

        /// <summary>
        ///     删除表
        /// </summary>
        [TestMethod]
        public void DropTest()
        {
            FolderDatabase.Drop();
            FolderDatabase.Create();
            FolderDatabase.Insert("test_data", "");
            var folders = FolderDatabase.GetFolders();
            foreach (var folder in folders)
                Assert.AreEqual("test_data", folder.FolderPath);
        }

        /// <summary>
        ///     通过主键删除并读出数据
        /// </summary>
        [TestMethod]
        public void DeleteKeyAndGetFoldersTest()
        {
            FolderDatabase.Drop();
            FolderDatabase.Create();
            FolderDatabase.Insert("test_data_1", "");
            FolderDatabase.Insert("test_data_2", "");
            FolderDatabase.Insert("test_data_3", "");
            FolderDatabase.Insert("test_data_4", "");
            FolderDatabase.Insert("test_data_5", "");
            FolderDatabase.Delete("test_data_1");
            FolderDatabase.Delete("test_data_3");
            FolderDatabase.Delete("test_data_5");
            var folders = FolderDatabase.GetFolders();
            var count = 2;
            foreach (var folder in folders)
            {
                Assert.AreEqual("test_data_" + count, folder.FolderPath);
                count += 2;
            }
        }

        /// <summary>
        ///     通过删除记录并读出数据
        /// </summary>
        [TestMethod]
        public void DeletePathAndGetFoldersTest()
        {
            FolderDatabase.Drop();
            FolderDatabase.Create();
            FolderDatabase.Insert("test_data_1", "");
            FolderDatabase.Insert("test_data_2", "");
            FolderDatabase.Insert("test_data_3", "");
            FolderDatabase.Insert("test_data_4", "");
            FolderDatabase.Insert("test_data_5", "");
            FolderDatabase.Delete("test_data_1");
            FolderDatabase.Delete("test_data_3");
            FolderDatabase.Delete("test_data_5");
            var folders = FolderDatabase.GetFolders();
            var count = 2;
            foreach (var folder in folders)
            {
                Assert.AreEqual("test_data_" + count, folder.FolderPath);
                count += 2;
            }
        }
    }
}