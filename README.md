# NameSorter

## Packing the Tool

To create a NuGet package for the tool:
Run the following command:

```bash
dotnet pack -c Release
```

This will generate a NuGet package in the `./NameSorter/bin/Release` directory.

## Installing the Tool Locally

To install the tool from the local package:
```bash
dotnet tool install --add-source ./NameSorter/bin/Release name-sorter
```

## Run the project

```bash
dotnet name-sorter unsorted-names-list.txt
```


