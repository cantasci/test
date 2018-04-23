import { Component, Inject, OnInit } from '@angular/core';
import { ApiStudyService } from '../../services/api-study.service';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {
    
    products: Product[] = []
    pageIndex:number = 0
    pageSize:number = 50
    maxPage:number=1
    term:string = ""  

    pagination:any = {
        TotalItems: 100,
        CurrentPage: 1,
        PageSize: 10,
        TotalPageLinkButtons: 5,
        RowsPerPageOptions: [10, 20, 30, 50, 100]
      };

    constructor(private productService:ApiStudyService) { 
    }

    ngOnInit(): void {
        this.searchForm()
    }


    searchForm(){ 
     this.productService.search(this.term, this.pageIndex, this.pageSize)
        .subscribe(result=> {
            this.products = result.json() as Product[];
        }, error => console.error(error));
    }

    nextPage() {
        this.pageIndex++;
        this.searchForm();
    }

    prevPage(){
        this.pageIndex--;
        if(this.pageIndex < 0)
            this.pageIndex = 0;

        this.searchForm();
    }

    hasPrevPage(){
        return this.pageIndex<=this.maxPage
    }

    hasNextPage(){
        return this.pageIndex+1==this.maxPage
    }

    hasSearchLength(){
        return this.term.length > 0
    }


    /* Paging Component metod */
    onPagination(event:any) {
        this.pagination.CurrentPage = event.currentPage;
        this.pagination.TotalItems = event.totalItems;
        this.pagination.PageSize = event.pageSize;
        this.pagination.TotalPageLinkButtons = event.totalPageLinkButtons;
      }
}

interface Product {
    id: number;
    name: string;
    lastModified: Date; 
}
