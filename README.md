# Blazor WASM & WEB API Mini Cart App

This is the mini shopping cart app crafted with

- .NET8
- Blazor WebAssembly
- Dotnet Core
- EF Core
- MySQL

## Features

- Product Display
- Add To Cart
- Delete Item
- Update Quantity
- Payment (Credit and PayPal)

## Scripts

### Dotnet Create Solution

```bash
dotnet new sln -n BlazorAPICartApp.sln
```

### Dotnet Create Blazor Wasm

```bash
dotnet new blazorwasm -o Cart.Web
```

### Dotnet Create Web API

```bash
dotnet new webapi -o Cart.Api
```

### Dotnet Create Lib

```bash
dotnet new classlib -n Cart.Lib
```

### Add to Sln

```bash
dotnet sln add Cart.Web/Cart.Web.csproj
dotnet sln add Cart.Api/Cart.Api.csproj
dotnet sln add Cart.Lib/Cart.Lib.csproj
```

### Reference Project (P2P)

```bash
dotnet add reference ../Cart.Lib/Cart.Lib.csproj
```

### EF Migration

```bash
dotnet ef migrations add Init
```

```bash
dotnet ef database update
```