// global exports go here...
import { API_BASE_URL } from '$env/static/private'
import { ToyApiClient } from "./apiclient";

export const ApiClient = new ToyApiClient(API_BASE_URL);