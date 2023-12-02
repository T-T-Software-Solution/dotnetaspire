# .NET Aspire
ยินดีต้อนรับเข้าสู่ Repository นี้นะครับ
โดยเป้าหมายหลักของเราคือการพามาทดลองใช้ .NET Aspire เพื่อทำการพัฒนา Cloud Native Application ได้สะดวกรวดเร็วขึ้นมากๆครับผม

![](https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2023/11/Aspire-CTAs1.png)

## Video
ดูรายละเอียดทั้งหมดเป็น Video ได้บน Youtube นะคร้าบ : )
https://youtu.be/iakfoNJ9MXM

## Slide
https://docs.google.com/presentation/d/1EreMAJKNMj_kvNsJn4ygTrcmXj8797_7mdqim_xMVeg/edit?usp=sharing

![](https://private-user-images.githubusercontent.com/9103080/287311832-0059e8c8-d07a-4f22-bf1a-7503500325eb.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTEiLCJleHAiOjE3MDE0NDU1MzUsIm5iZiI6MTcwMTQ0NTIzNSwicGF0aCI6Ii85MTAzMDgwLzI4NzMxMTgzMi0wMDU5ZThjOC1kMDdhLTRmMjItYmYxYS03NTAzNTAwMzI1ZWIucG5nP1gtQW16LUFsZ29yaXRobT1BV1M0LUhNQUMtU0hBMjU2JlgtQW16LUNyZWRlbnRpYWw9QUtJQUlXTkpZQVg0Q1NWRUg1M0ElMkYyMDIzMTIwMSUyRnVzLWVhc3QtMSUyRnMzJTJGYXdzNF9yZXF1ZXN0JlgtQW16LURhdGU9MjAyMzEyMDFUMTU0MDM1WiZYLUFtei1FeHBpcmVzPTMwMCZYLUFtei1TaWduYXR1cmU9Mzk5NjE1YjNmZDJjYWNjNTg0NjYyMzEwMWE4ZWU2NGQ1YmQ5MWYxZWI2ZDFmZGNjNzdkMTVlMTc2MjljYjMzMSZYLUFtei1TaWduZWRIZWFkZXJzPWhvc3QmYWN0b3JfaWQ9MCZrZXlfaWQ9MCZyZXBvX2lkPTAifQ.lCK-YVTJilaKc7Q_QdrAYALKYO8C9ODSTNHy2217hWg)

## วิธีรันโปรเจค
1. ติดตั้ง [Docker Desktop](https://docs.docker.com/get-docker/)
2. ติดตั้ง [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
3. ติดตั้ง [.NET Aspire workload](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-workload-install)
   ```
   dotnet workload install aspire
   ```
4. สร้าง .NET Aspire Project โดยใช้ Redis Cache มาช่วยเก็บ Output
   ```
   dotnet new aspire-starter --use-redis-cache --output AspireSample
   ```
5. สั่งรัน Project
   ```
   dotnet run --project AspireSample/AspireSample.AppHost
   ```

## วิธีเพิ่ม RabbitMq Container
1. ติดตั้ง Package เพิ่มเติมที่ `AspireSample.Web` Project
   ```
   dotnet add package Aspire.RabbitMQ.Client --prerelease
   ```
   
   เสร็จแล้วกลับไปเพิ่มคำสั่งนี้ที่ไฟล์ `Program.cs`
   ```
   builder.AddRabbitMQ("messaging");
   ```
2. เพิ่ม 2 บรรทัดนี้ที่ `AspireSample.AppHost`
   ```
   var rabbit = builder.AddRabbitMQContainer("rabbit");

    .WithReference(rabbit)
   ```