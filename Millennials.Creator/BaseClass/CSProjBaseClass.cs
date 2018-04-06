using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millennials.Creator.BaseClass
{
    public static class CSProjBaseClass
    {
        //0-project's id, 1-Namespace, 2-AssemblyName
        // 3-files, 4-project's references, 5 - DLLs, 6 - embedded
        public const string baseClassTemplate =

@"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""4.5"" DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <PropertyGroup>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ProductVersion>9.0.30729</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{0}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>{1}</RootNamespace>
    <AssemblyName>{2}</AssemblyName>
    <TargetFrameworkVersion>v4.5</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include=""System"" />
    {5}
    <Reference Include=""System.Core"">
      <RequiredTargetFramework>4.5</RequiredTargetFramework>
    </Reference>
    <Reference Include=""System.Xml.Linq"">
      <RequiredTargetFramework>4.5</RequiredTargetFramework>
    </Reference>
    <Reference Include=""System.Data.DataSetExtensions"">
      <RequiredTargetFramework>4.5</RequiredTargetFramework>
    </Reference>
    <Reference Include=""System.Data"" />
    <Reference Include=""System.Xml"" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include=""Properties\AssemblyInfo.cs"" />
    {3}
  </ItemGroup>
  <ItemGroup>
  {4}
  </ItemGroup>
  {6}
  <Import Project=""$(MSBuildToolsPath)\Microsoft.CSharp.targets"" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name=""BeforeBuild"">
  </Target>
  <Target Name=""AfterBuild"">
  </Target>
  -->
</Project>";

        // 0- file name
        public const string baseFilesTemplate =
        @"
<Compile Include=""{0}"" />";

        public const string baseReferenceTemplate =
        @"
<Reference Include=""{0}"" />";

        public const string embeddedResourceTemplate =
        @"
<ItemGroup>
    <EmbeddedResource Include=""{0}"" />
</ItemGroup>";

        //0=Path, 1-GUID, 2-Name
        public const string baseProjectReferenceTemplate =
        @"
        <ProjectReference Include=""..\{0}"">
          <Project>{1}</Project>
          <Name>{2}</Name>
        </ProjectReference>";
    }
}