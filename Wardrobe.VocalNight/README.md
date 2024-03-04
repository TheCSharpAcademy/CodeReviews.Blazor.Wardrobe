# Wardrobe

### Project

Blazor project for the C# Academy

https://www.thecsharpacademy.com/project/39

### Challenges

Blazor in itself is fun! It's similar to MVC in a good way.

My biggest stump i nthis project was actually the way to communicate with the "backend" and how to treat the image upload in the crud.
I was stuck using the httpclient and having difficulty with image treatment untill i found a few videos that injected the services(that have the repository) inside the razor component, so intead of using httpclient and the controllers, you simply use services.

I still don't know if this is the correct way to design blazor projects, but apparently it is one of the ways to do it. Frankly the microsoft documentantion is still lacking and chatGPT dosn't offer updated examples since it's stuck in 2022, so from now on i will favor this type of design.

Overall it was fun to use Blazor.