import * as nativeAxios from 'axios'
import { getFullToken, removeToken, HTTP_STATUS } from './../Utils'

const BASE_URL = 'http://localhost:5000/api';
const ERROR_TIMEOUT = 'Infelizmente estamos com problemas de conexão, tente novamente mais tarde.'

const createAxios = () => {
    const axiosInstance = nativeAxios.create({
        baseURL: BASE_URL
    })

    axiosInstance.defaults.headers.common.Authorization = getFullToken()

    axiosInstance.interceptors.response.use(
        response => response,
        error => {
            if (!error.response) {
                throw new Error(ERROR_TIMEOUT)
            }

            if (error.response.status === HTTP_STATUS.UNAUTHORIZED) {
                removeToken()
                window.location.replace('/login')
            }

            return Promise.reject(error)
        }
    )

    return axiosInstance;
}

export default createAxios()
