const ACCESS_TOKEN_KEY = 'access_token'

export const getToken = () => localStorage.getItem(ACCESS_TOKEN_KEY)

export const getUserData = () => {
    let userData = {}
    try {
        userData = JSON.parse(atob(getToken().split('.')[1]))
    } catch (err) {
        return userData
    }

    return userData
}

export const removeToken = () => { localStorage.removeItem(ACCESS_TOKEN_KEY) }

export const getFullToken = () => `Bearer ${getToken()}`

export const getCpf = () => getUserData().unique_name