# EasyDBDriver
Simple connector for [EasyDB](https://github.com/ingSlonik/easy-db)

Nuget
```
PM> Install-Package EasyDBDriver -Version 2.0.21
```
Query example (more examples in test project):
```
  var query = FilterExtension.And(new[]{
                Filter<TestEntity>.Field(e => e.StringItem).Equal(key),
                Filter<TestEntity>.Field(e => e.IntItem).Greater(12)
                });
  var loadedEntities = await connector.GetCollectionAsync(query);
```