# PCF_Extractor
Extract Bill of Material from PCF's


This program can be used to process PCF files that in the past have always required a licensed version of the ISOGEN engine, either in the form of Spoolgen or other similar softwares. The Deliverable will be a Bill of Material's Report, containing all items that exist within the PCF file, includeing the Qty / length of said items.


The goal is to be able to feed the software a PCF file, and have an excel BOM generated, requireing no user manipulation to be able to easily identify materials, descriptions, specs, qty's / lengths, as well as any other needed information.


**Estimated % complete** 60%


  **Tasks:**
  - [x] Extracts lines into a DataTable (as of now a user can use this raw data to come up with a BOM)
- [ ] Split the single cell into multiple cells within a single row based on semi-colons
- [ ] Apply formatting and functions to the correct cells to end up with a clean report.
- [ ] Apply standard GUI structure to be in line with Epic Software appearance.
