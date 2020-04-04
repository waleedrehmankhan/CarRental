declare module server {
	interface getCustomerInput extends pagedAndSortedInputDto {
		CustomerID: number;
		CustomerCode: string;
		FirstName: string;
		LastName: string;
	}
}
