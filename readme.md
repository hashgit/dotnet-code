Assumptions
===========
I assume each data feed was to be handled separately and they don't have to be merged. I read each data file individually and display the results.

The data is sorted in the main.cs file and not inside the business layer. I could do it in the business layer so you always get sorted list but it is not clear if it has to be like that or is it just for display purpose.

I only read the horse data from the XML file using XPath because I assume rest of the data is not required. Otherwise I would have deserialised it into an object.
