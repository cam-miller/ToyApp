namespace dto {
    export interface ToyAppCollectionResponse<T> {
        items: Array<T>;
        count: number;
        offset: number;
    }
}