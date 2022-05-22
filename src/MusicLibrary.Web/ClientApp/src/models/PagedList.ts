export interface PagedList<T> {
  data: T[];
  pageNumber: number;
  pageSize: number;
  totalCount: number;
}
