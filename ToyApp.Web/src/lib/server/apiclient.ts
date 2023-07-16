import { Result } from "typescript-result";
import type { ApiError, BaseError } from "./errors/errors";

export class ToyApiClient {

    private _baseurl: string

    constructor(baseurl: string) {
        this._baseurl = baseurl
    }

    public async AddTodoItem(req: dto.CreateTodoItemRequest): Promise<Result<BaseError | ApiError, dto.TodoItemResponse>> {
        return await this.PostAsync<dto.TodoItemResponse>("todo", req);
    }

    public async GetTodoItem(id: string): Promise<Result<BaseError | ApiError, dto.TodoItemResponse>> {
        return await this.GetAsync<dto.TodoItemResponse>(`todo/${id}`);
    }

    public async GetTodoItems(): Promise<Result<BaseError | ApiError, dto.ToyAppCollectionResponse<dto.TodoItemResponse>>> {
        return await this.GetAsync<dto.ToyAppCollectionResponse<dto.TodoItemResponse>>(`todos`);
    }

    private async PostAsync<T>(path: string, data: any): Promise<Result<BaseError | ApiError, T>> {
        try {
            const resp = await fetch(`${this._baseurl}/${path}`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(data)
            })
            if (!resp.ok) {
                var body = await resp.text();
                return Result.error({
                    msg: `Status code did not indicate success: ${body}`,
                    statusCode: resp.status
                } as ApiError)
            }
            const rjson = await resp.json()
            return Result.ok(rjson as T);
        }
        catch (e) {
            return Result.error({
                msg: e as string
            } as BaseError);
        }
    }

    private async GetAsync<T>(path: string): Promise<Result<BaseError | ApiError, T>> {
        try {
            const resp = await fetch(`${this._baseurl}/${path}`, {
                method: "GET",
            })
            if (!resp.ok) {
                var body = await resp.text();
                return Result.error({
                    msg: `Status code did not indicate success: ${body}`,
                    statusCode: resp.status
                } as ApiError)
            }
            const rjson = await resp.json()
            return Result.ok(rjson as T);
        }
        catch (e) {
            return Result.error({
                msg: e as string
            } as BaseError);
        }
    }

}