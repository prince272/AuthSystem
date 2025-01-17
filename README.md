## Getting Started

Follow these steps to get your development environment up and running.

### Prerequisites

Before you begin, ensure you have the following installed:

- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/)
- [Visual Studio Code](https://code.visualstudio.com/) (optional)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (latest version)
- [Node.js v20](https://nodejs.org/en/) (latest version, only required if you are using Next.js or Expo)

### Installation

   Restore the project dependencies:

   ```bash
   dotnet restore
   ```

   Open the solution file in Visual Studio:

   ```bash
   start YourProjectName.sln
   ```

   - **Using Visual Studio:**

     Open Visual Studio, select "Create a new project," search for "Authsystem," select it, and follow the prompts to create your project.


   **Mobile Development Guide:**

   Set up your mobile development environment by following these steps:

   - **Set Up Your Expo Development Environment**

     Follow the official [Expo documentation](https://docs.expo.dev/get-started/set-up-your-environment/) to install all the necessary tools, configure your environment, and run your first Expo project.

   - **Use React Native Paper Components**

     Since we're using [React Native Paper](https://reactnativepaper.com/), you can refer to the following documentation to get started with its components and features: [Getting started with React Native Paper](https://callstack.github.io/react-native-paper/docs/guides/getting-started)  



## Endpoint documentation
**Version:** 1.0  
**Base URL:** https://localhost:7315/swagger

### Security Scheme
This API uses **JWT Bearer Authentication**. Provide the token in the request headers as:  
```
Authorization: Bearer <your_token>
```

---

## Endpoints

### **1. Register User**
**POST** `/users/register`  
Registers a new user account.

#### Request Body
| Field       | Type   | Nullable | Description         |
|-------------|--------|----------|---------------------|
| firstName   | string | Yes      | First name of user. |
| lastName    | string | Yes      | Last name of user.  |
| username    | string | Yes      | Username.           |
| password    | string | Yes      | Password.           |

**Response Codes**  
- **200**: Success  
- **400**: Bad Request  

---

### **2. Login User**
**POST** `/users/login`  
Logs into an existing user account.

#### Request Body
| Field    | Type   | Nullable | Description |
|----------|--------|----------|-------------|
| username | string | Yes      | Username.   |
| password | string | Yes      | Password.   |

**Response Codes**  
- **200**: Success  
- **400**: Bad Request  

#### Response Example
```json
{
    "id": "string",
    "firstName": "string",
    "lastName": "string",
    "userName": "string",
    "email": "string",
    "emailConfirmed": true,
    "phoneNumber": "string",
    "phoneNumberConfirmed": true,
    "passwordConfigured": true,
    "roles": ["string"],
    "tokenType": "string",
    "accessToken": "string",
    "accessTokenExpiresAt": "2024-12-31T23:59:59Z",
    "refreshToken": "string",
    "refreshTokenExpiresAt": "2024-12-31T23:59:59Z"
}
```

---

### **3. Refresh Token**
**POST** `/users/refresh-token`  
Refreshes the current user's access token.

#### Request Body
| Field         | Type   | Nullable | Description          |
|---------------|--------|----------|----------------------|
| refreshToken  | string | Yes      | The refresh token.   |

**Response Codes**  
- **200**: Success  
- **400**: Bad Request  

---

### **4. Logout User**
**POST** `/users/logout`  
Logs out the current user.

#### Request Body
| Field              | Type    | Nullable | Default | Description                         |
|--------------------|---------|----------|---------|-------------------------------------|
| refreshToken       | string  | Yes      |         | The refresh token.                 |
| allowMultipleTokens| boolean | No       | true    | Allow multiple active tokens.      |

**Response Codes**  
- **200**: Success  
- **400**: Bad Request  

---

### **5. Get User Profile**
**GET** `/users/me`  
Retrieves the current user's profile.

**Response Codes**  
- **200**: Success  

#### Response Example
```json
{
    "id": "string",
    "firstName": "string",
    "lastName": "string",
    "userName": "string",
    "email": "string",
    "emailConfirmed": true,
    "phoneNumber": "string",
    "phoneNumberConfirmed": true,
    "passwordConfigured": true,
    "roles": ["string"]
}
```

---

## Schemas

### **CreateAccountForm**
| Field     | Type   | Nullable | Description          |
|-----------|--------|----------|----------------------|
| firstName | string | Yes      | First name of user.  |
| lastName  | string | Yes      | Last name of user.   |
| username  | string | Yes      | Username.            |
| password  | string | Yes      | Password.            |

### **SignInForm**
| Field     | Type   | Nullable | Description |
|-----------|--------|----------|-------------|
| username  | string | Yes      | Username.   |
| password  | string | Yes      | Password.   |

### **RefreshTokenForm**
| Field         | Type   | Nullable | Description |
|---------------|--------|----------|-------------|
| refreshToken  | string | Yes      | Refresh token. |

### **SignOutForm**
| Field              | Type    | Nullable | Default | Description                         |
|--------------------|---------|----------|---------|-------------------------------------|
| refreshToken       | string  | Yes      |         | The refresh token.                 |
| allowMultipleTokens| boolean | No       | true    | Allow multiple active tokens.      |

---

**Generated by AuthSystem.WebApi**
