export interface IError {
    kind: string,
    msg: string
}

export interface BaseError extends IError {
    kind: "base"
}

export interface ApiError extends IError {
    kind: "api",
    statusCode: number
}