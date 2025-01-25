# NpiRegistry
A client package for interacting with the United States National Provider Identifier (NPI) registry API

## Introduction
From the [CMS.gov web site](https://www.cms.gov/regulations-and-guidance/administrative-simplification/nationalprovidentstand):

> The National Provider Identifier (NPI) is a Health Insurance Portability and Accountability Act (HIPAA) Administrative Simplification Standard. 
> The NPI is a unique identification number for covered health care providers. Covered health care providers and all health plans and 
> health care clearinghouses must use the NPIs in the administrative and financial transactions adopted under HIPAA. The NPI is a 10-position, 
> intelligence-free numeric identifier (10-digit number). 

This package provides easy-to-use functionality that queries the NPI registry API. Version 2.1 of the API is the only supported version in this package. CMS has 
deprecated previous versions of the API, so that shouldn't be a problem.

## Example Usage

To retrieve the first 50 registered healthcare providers in the state of Colorado with a last name of "Smith":

```
var searchReq = new NpiRegistrySearchRequest();
searchReq.SetLastName("Smith");
searchReq.SetState("CO");
searchReq.SetLimit(50);
var searchResults = await searchReq.Execute();
```

To retrieve information for a specific NPI number, in this case the fictitious number `1234567890`:

```
var searchReq = new NpiRegistrySearchRequest();
searchReq.SetNumber("1234567890");
var searchResult = await searchReq.Execute();
```

## Issues

The CMS.gov web service may rate-limit or restrict the number of queries per hour. For full details on the API, check out [their website](https://npiregistry.cms.hhs.gov/api-page).
