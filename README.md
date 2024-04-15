# PropTrac Backend

**Quick Links:**

[![Static Badge](https://img.shields.io/badge/frontend%20repo-navy?style=for-the-badge&logo=github)](https://github.com/calebsylvia/PropTrac) &ensp; [![Website](https://img.shields.io/website?url=https%3A%2F%2Fproptrac-app.vercel.app%2F&up_message=in%20development&up_color=blue&down_color=8B0000&style=for-the-badge&logo=vercel&label=frontend)](https://proptrac-app.vercel.app/)


## API

**Details:** API is deployed on Azure.

Base URL: https://proptracapi.azurewebsites.net

> [!IMPORTANT]
> Please view the tables below for specific endpoints/ requests. 
> - These endpoints are for the internal team only


<h4 align="center">Table 1: User Controller Endpoints</h4>

| Description                              | HTTP Method | Endpoint                          | Parameter Type | Parameter Requirements |
| -------------                            | ----------- | -------------                     | -------------  | ------------- |
| Create an Account *(Manager or Tenant)*  | `POST`      | /User/AddUser                     | Body           | int ID, string Username, string Password, string Email, bool IsManager, string FirstName, string LastName, string SecurityAnswer, int SecurityQuestionID |
| Login *(Manager or Tenant)*              | `POST`      | /User/Login                       | Body           | string UsernameOrEmail, string Password |
| Get All User Info (Role)                 | `GET`       | /User/GetUserInfoByUsernameOrEmail/{usernameOrEmail}| URL            | string UsernameOrEmail |
| Update User                              | `PUT`       | /User/Update                      | Body           | .. |
| Delete User                              | `DELETE`    | /User/DeleteUser/{userToDelete}   | URL            | .. |
| Update Username                          | `PUT`       | /User/UpdateUser/{id}/{username}  | URL            | .. |

<h4 align="center">Table 2: Password Controller Endpoints</h4>

| Description                         | HTTP Method | Endpoint                                    | Parameter Type | Parameter Requirements |
| -------------                       | ----------- | -------------                               | -------------  | ------------- |
| Get List of all Security Questions  | `GET`       | /Password/SecurityQuestionList              | N/a            | None |
| Request Password Reset              | `POST`      | /Password/RequestReset                      | Body           | string UsernameOrEmail |
| Response for Reset                  | `POST`      | /Password/ResponseForReset                  | Body           | string UsernameOrEmail, string SecurityAnswer |
| Password Reset                      | `PUT`       | /Password/ResetPassword                     | Body           | string UsernameOrEmail, string SecurityAnswer, string NewPassword |

<h4 align="center">Table 3: Tenant Controller Endpoints</h4>

| Description                         | HTTP Method | Endpoint                                    | Parameter Type | Parameter Requirements |
| -------------                       | ----------- | -------------                               | -------------  | ------------- |
| Get All Tenant Dashboard Info       | `GET`       | /Tenant/GetTenantDashboardInfo/{userId}     | URL            | int userId |
| Submit Maintenance Request          | `POST`      | /Tenant/AddMaintenanceRequest               | Body           | string Description, string Priority, string Category, byte[]? Image, int UserID |

<h4 align="center">Table 4: Manager Controller Endpoints</h4>

| Description                               | HTTP Method | Endpoint                                     | Parameter Type | Parameter Requirements |
| -------------                             | ----------- | -------------                                | -------------  | ------------- |
| Manager Dashboard Property Stats          | `GET`       | /Manager/GetPropertyStatsByUserID/{userId}   | URL            | int userId    |
| Manager Dashboard Maintenance             | `GET`       | /Manager/GetMaintenanceStatsByUserID/{userId}| URL            | int userId    |
| Manager Dashboard Month Profit Or Loss    | `GET`       | /Manager/GetMonthlyProfitOrLoss/{userId}/{month}/{year}| URL            | int userId, int month, int year    |
| Manager Dashboard Profit Or Loss Overview | `GET`       | /Manager/GetPastSixMonthsProfitOrLoss/{userId}/{month}/{year}| URL            | int userId, int month, int year    |
| Manager Dashboard Projected Overview      | `GET`       | /Manager/GetProjectedProfitOrLoss/{userId}/{month}/{year}| URL            | int userId, int month, int year    |

<p align="right">Tables 1, 2, 3, 4: API endpoints updated April 15, 2024</p>


## Database

**Details:** Database is Azure SQL. (5gb max)

<h4 align="center">Entity Relationship Diagram</h4>

![Entity relationship diagram](ERD_V2.4_4.15.2024.png)

<p align="right">Figure 2: ERD illustrating database schema updated April 15, 2024</p>
