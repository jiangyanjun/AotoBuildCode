using System;

namespace Millennials.Creator.BaseClass
{
    public static class HbmBaseClass
    {
        public const string baseClassTemplate =

       @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"" assembly=""{0}"" namespace=""{1}"">
  
  <class name=""{2}"" table=""{3}"" lazy=""false"">
    
    {4}
    {5}
  </class>
  
</hibernate-mapping>";

        // 0 - id or property, 4 - other configurations..
        public const string basePropertyTemplate =

        @"
    <{0} name=""{1}"" column=""{2}"" type=""{3}"" {4} />";
    }
}