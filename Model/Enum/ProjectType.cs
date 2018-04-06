using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Creation project steps 
    /// </summary>
    public enum NewProjectStep : int
    {
        CONNECTION = 1,
        TABLE = 2,
        CONFIG = 3,
        SOLUTION = 4
    }

    /// <summary>
    ///  Database's objects image
    /// </summary>
    public enum DBImage : int
    {
        TABLE = 0,
        FIELD = 1,
        PRIMARY_KEY = 2,
        FOREIGN_KEY = 3
    }

    /// <summary>
    ///  Architecture types
    /// </summary>
    public enum Architecture : int
    {
        MVC = 1,
        THREETIER = 2
    }

    /// <summary>
    /// Data Access types
    /// </summary>
    public enum DataAccess : int
    {
        ADONET = 1,
        LINQ = 2,
        NHIBERNATE = 3
    }

    /// <summary>
    /// Project types
    /// </summary>
    public enum ProjectType : int
    {
        MODEL = 1,
        VIEW = 2,
        CONTROLLER = 3,
        BUSINESS = 4,
        DAO = 5
    }
}
