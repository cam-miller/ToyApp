import { error, type Actions } from '@sveltejs/kit';
import { ApiClient } from '$lib/server';
import type { BaseError, ApiError } from '$lib/server/errors/errors';
import type { PageServerLoad } from './$types';


export const load = (async () => {
    const res = await ApiClient.GetTodoItems();
    if (res.isSuccess()) {
        return res.value;
    }
    else {
        console.log(res.error.msg)
        // should really be handling this properly.
        throw error(500);
    }
}) satisfies PageServerLoad;

export const actions = {
    default: async ({ request }) => {
        const data = await request.formData();
        const [day, month, year] = (data.get("dueDate") as string).split("/");
        // months are zero-indexed...
        const date = new Date(+year, +month - 1, +day);
        const req: dto.CreateTodoItemRequest = {
            title: data.get("name") as string,
            dueDate: date
        }
        const res = await ApiClient.AddTodoItem(req);
        if (res.isSuccess()) {
            return { success: true, data: res.value }
        }
        else {
            switch (res.error.kind) {
                case "api":
                    const err = res.error as ApiError;
                    console.log(`Error! Status: ${err.statusCode}, Msg: ${err.msg}`);
                    break;
                default:
                    console.log(res.error.msg);
            }
        }
    }
} satisfies Actions;