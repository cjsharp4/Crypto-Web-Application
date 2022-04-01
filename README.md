# Crypto-Web-Application

Final Project for my Distributed Systems and Architecture class at ASU. 

The focus of this project was to learn how implement RESTful and SOAP services that we created earlier in the semester into a web application. Some of the webservices were made completed from scratch and others were created by wrapping other APIs in code that gave the API new functionality (example: used coingeeko API to get cryptocurrency prices and wrote new code to get a conversion rate of USD to any desired cryptocurrency). The UI of the web application is rough, but was not the main focus of this project. Other features such as user account registration, sign in, cookies, user role authentication using Forms Authentication, global handlers, etc were also implemented.

We orignally had our web application hosted on AWS EC2 instances provided by ASU. I have reverted the application to host the web services on localhost when starting up the program. This seems to have occured due to new security requirements (HTTPS) from the ASU service repository.


Note:
Since submitting this project, it seems that a new error with the captcha service used for registering an account has occured.

Here are some pictures of the web application:

![Capture1](https://user-images.githubusercontent.com/65328908/161333437-8233aa6e-e21e-4b9a-87f3-29298bedb4ce.PNG)

![Capture2](https://user-images.githubusercontent.com/65328908/161333454-ab31e041-1bf0-4939-bbea-10d60c79b0ae.PNG)

![Capture3](https://user-images.githubusercontent.com/65328908/161333458-39c85881-5e4a-43e4-981e-491fd67e8fdb.PNG)

![Capture4](https://user-images.githubusercontent.com/65328908/161333462-e4837c9c-d245-49c7-a2c6-46f3939f6ec5.PNG)
