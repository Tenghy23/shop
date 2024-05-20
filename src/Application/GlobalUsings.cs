﻿global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using Domain.AggregatesModel.CartAggregate;
global using Domain.AggregatesModel.CategoryAggregate;
global using Domain.AggregatesModel.DiscountAggregate;
global using Domain.AggregatesModel.InventoryAggregate;
global using Domain.AggregatesModel.OrderAggregate;
global using Domain.AggregatesModel.OrderDetailsAggregate;
global using Domain.AggregatesModel.PaymentDetailsAggregate;
global using Domain.AggregatesModel.ProductAggregate;
global using Domain.AggregatesModel.UserAggregate;
global using Domain.AggregatesModel.AddressAggregate;
global using Infrastructure;
global using Infrastructure.Data;
global using Microsoft.OpenApi.Models;
global using Microsoft.EntityFrameworkCore;
global using System.Reflection;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Domain.Exceptions;
global using Domain.Utilities;
global using Microsoft.AspNetCore.Mvc;
global using System.Diagnostics;
global using System.Runtime.Serialization;
global using Application.Models.DTOs;
global using Application.Helpers;
global using Microsoft.AspNetCore.Http;
global using System.Runtime.CompilerServices;
global using Application.Interfaces;
global using Application.Services;
global using Domain.Helpers.MockData;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using Microsoft.AspNetCore.Identity;