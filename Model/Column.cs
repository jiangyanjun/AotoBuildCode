﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Column
    {
           #region 私有属性

        private Table table;
        private string name;
        private bool nullable;
        private string type;
        private int? characterMaximumLength;
        private bool primaryKey;
        private bool foreignKey;

        #endregion 

        #region 公有属性

        public Table Table
        {
            get { return table; }
            set { table = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public bool Nullable
        {
            get { return nullable; }
            set { nullable = value; }
        }

        public int? CharacterMaximumLength
        {
            get { return characterMaximumLength; }
            set { characterMaximumLength = value; }
        }

        public bool PrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; }
        }

        public bool ForeignKey
        {
            get { return foreignKey; }
            set { foreignKey = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        #endregion
    }
}
